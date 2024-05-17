import { injectable } from 'inversify';
import { action, makeObservable, observable } from 'mobx';
import { z } from 'zod';

export interface IDocumentEditingModalVM {
  isLoading: boolean;
  isOpened: boolean;
  uploadFormSchema: z.ZodObject<any>;
  upload: (formData: z.infer<any>) => void;
  setIsOpened: (isOpened: boolean) => void;
}

@injectable()
class DocumentEditingModalVM implements IDocumentEditingModalVM {
  @observable
  public isLoading: boolean = false;

  @observable
  public isOpened: boolean = false;


  private formData: z.infer<typeof this.uploadFormSchema> | null = null;

  constructor() {

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

  public setIsOpened = (isOpened: boolean) => {
    this.isOpened = isOpened;
  }

  @action
  public upload = (formData: z.infer<typeof this.uploadFormSchema>): void => {
    this.formData = formData;
    // this.sengUploadRequest();
  }

  // @action.bound
  // public sengUploadRequest = flow(function *(this: DocumentEditingModalVM) {
  //   if (this.formData === null)
  //     return;
  //
  //   const payload: INewDocument = {
  //     name: this.formData.documentName,
  //     downloadUrl: this.formData.url,
  //     description: ''
  //   }
  //
  //   try {
  //     this.formData = null;
  //     this.setIsLoading(true);
  //     yield this.api.create(payload);
  //   } finally {
  //     this.setIsLoading(false);
  //     this.setIsOpened(false);
  //   }
  // });
}

export default DocumentEditingModalVM;
