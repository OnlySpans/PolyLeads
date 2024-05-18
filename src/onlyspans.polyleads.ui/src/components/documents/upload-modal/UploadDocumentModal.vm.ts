import { inject, injectable } from 'inversify';
import { action, flow, makeObservable, observable } from 'mobx';
import { z } from 'zod';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import type { IDocumentApi } from '@/services/api/document/documentApi';
import { INewDocument } from '@/data/abstractions/INewDocument';
import type { IDocumentsTableVM } from '@/components/DocumentsManager/DocumentsTable/DocumentsTableVM';
import type { IRoleApi } from '@/services/api/role/roleApi';

export interface IUploadDocumentModalVM {
  isLoading: boolean;
  isOpened: boolean;
  isEnabled: boolean;
  uploadFormSchema: z.ZodObject<any>;
  upload: (formData: z.infer<any>) => void;
  setIsOpened: (isOpened: boolean) => void;
}

@injectable()
class UploadDocumentModalVM implements IUploadDocumentModalVM {
  @observable
  public isLoading: boolean = false;

  @observable
  public isOpened: boolean = false;

  @observable
  public isEnabled: boolean = false;
  
  private readonly documentApi: IDocumentApi;
  
  private readonly roleApi: IRoleApi;

  private formData: z.infer<typeof this.uploadFormSchema> | null = null;

  private readonly documentsTableVM: IDocumentsTableVM;

  constructor(
    @inject(ServiceSymbols.IDocumentApi) documentApi: IDocumentApi,
    @inject(ServiceSymbols.IRoleApi) roleApi: IRoleApi,
    @inject(ServiceSymbols.IDocumentsTableVM) documentsTableVM: IDocumentsTableVM
  ) {
    this.documentApi = documentApi;
    this.roleApi = roleApi;
    this.documentsTableVM = documentsTableVM;

    this.getRole();
    makeObservable(this);
  }

  public readonly uploadFormSchema: z.ZodObject<any> = z
    .object({
      documentName: z
        .string({ required_error: 'Название должно быть заполнено' })
        .min(6, 'Название должно содержать не менее 6 символов')
        .max(100, 'Название должно содержать менее 100 символов'),
      url: z
        .string({ required_error: "Ссылка должна быть заполнена" })
        .url('Ссылку необходимо указать в формате URL')
    });

  @action
  public setIsLoading = (isLoading: boolean) => {
    this.isLoading = isLoading;
  };

  @action
  public setIsOpened = (isOpened: boolean) => {
    this.isOpened = isOpened;
  }

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
      yield this.documentApi.create(payload);
      this.documentsTableVM.loadDocuments();
    } finally {
      this.setIsLoading(false);
      this.setIsOpened(false);
    }
  });

  @action.bound
  public getRole = flow(function *(this: UploadDocumentModalVM) {
    try {
      const response = yield this.roleApi.getRole()
      const role = response.role;
      
      if (
          role === 'Admin' 
          || role === 'StudentUnionOrganizer' 
          || role === 'Headman'
      ){
        this.isEnabled = true;
      }
    } catch (e) {
      this.isEnabled = false;
    }
  });
}

export default UploadDocumentModalVM;
