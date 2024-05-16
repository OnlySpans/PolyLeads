import { inject, injectable } from 'inversify';
import { action, flow, makeObservable, observable } from 'mobx';
import { z } from 'zod';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import type { IDocumentApi } from '@/services/api/document/documentApi';
import { INewDocument } from '@/data/abstractions/INewDocument';

export interface IUploadDocumentModalVM {
  isLoading: boolean;
  uploadFormSchema: z.ZodObject<any>;
  upload: (formData: z.infer<any>) => void;
}

@injectable()
class UploadDocumentModalVM implements IUploadDocumentModalVM {
  @observable
  public isLoading: boolean = false;

  private readonly api: IDocumentApi;

  private formData: z.infer<typeof this.uploadFormSchema> | null = null;

  constructor(@inject(ServiceSymbols.IDocumentApi) api: IDocumentApi) {
    this.api = api;

    makeObservable(this);
  }

  public readonly uploadFormSchema: z.ZodObject<any> = z
    .object({
      documentName: z
        .string({ required_error: 'Название должно быть заполнено' })
        .min(6, 'Название должно содержать не менее 6 символов')
        .max(100, 'Название не должно быть более 100 символов'),
      url: z
        .string({ required_error: "Ссылка должна быть заполнена" })
        .url('Ссылка должна быть представлена в виде URL')
    });

  @action
  public setIsLoading = (isLoading: boolean) => {
    this.isLoading = isLoading;
  };

  @action
  public upload = (formData: z.infer<typeof this.uploadFormSchema>): void => {
    this.formData = formData;
    this.sengUploadRequest();
  }

  @action.bound
  public sengUploadRequest = flow(function *(this: UploadDocumentModalVM) {
    if (this.formData === null)
      return;

    const payload: INewDocument = {
      name: this.formData.documentName,
      downloadUrl: this.formData.url,
      description: ''
    }

    try {
      this.formData = null;
      this.setIsLoading(true);
      yield this.api.create(payload);
    } finally {
      this.setIsLoading(false);
    }
  });
}

export default UploadDocumentModalVM;
