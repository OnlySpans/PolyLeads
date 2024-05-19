import { inject, injectable } from 'inversify';
import { action, flow, makeObservable, observable } from 'mobx';
import { z } from 'zod';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import type { IDocumentApi } from '@/services/api/document/documentApi';
import { IDocument } from '@/data/abstractions/IDocument';
import type { IDocumentsTableVM } from '@/components/DocumentsManager/DocumentsTable/DocumentsTableVM';

export interface IEditDocumentModalVM {
  isLoading: boolean;
  isOpened: boolean;
  document: IDocument | null;
  editFormSchema: z.ZodObject<any>;
  editDocument: (formData: z.infer<any>) => void;
  setIsOpened: (isOpened: boolean) => void;
}

@injectable()
class EditDocumentModalVM implements IEditDocumentModalVM {
  @observable
  public isLoading: boolean = false;

  @observable
  public isOpened: boolean = false;

  @observable
  public document: IDocument | null = null;

  private readonly api: IDocumentApi;

  private formData: z.infer<typeof this.editFormSchema> | null = null;

  private readonly documentsTableVM: IDocumentsTableVM;

  constructor(
    @inject(ServiceSymbols.IDocumentApi) api: IDocumentApi,
    @inject(ServiceSymbols.IDocumentsTableVM) documentsTableVM: IDocumentsTableVM
  ) {
    this.api = api;
    this.documentsTableVM = documentsTableVM;

    makeObservable(this);
  }

  public readonly editFormSchema: z.ZodObject<any> = z
    .object({
      documentName: z
        .string({ required_error: 'Название должно быть заполнено' })
        .min(6, 'Название должно содержать не менее 6 символов')
        .max(100, 'Название не должно быть более 100 символов'),
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
  public editDocument = (formData: z.infer<typeof this.editFormSchema>): void => {
    this.formData = formData;
    this.sendEditedDocumentRequest();
  }

  @action.bound
  public sendEditedDocumentRequest = flow(function *(this: EditDocumentModalVM) {
    if (this.formData === null || this.document === null)
      return;

    this.document.name = this.formData.documentName

    try {
      this.formData = null;
      this.setIsLoading(true);
      yield this.api.edit(this.document);
      this.documentsTableVM.loadDocuments();
    } finally {
      this.setIsLoading(false);
      this.setIsOpened(false);
    }
  });
}

export default EditDocumentModalVM;
