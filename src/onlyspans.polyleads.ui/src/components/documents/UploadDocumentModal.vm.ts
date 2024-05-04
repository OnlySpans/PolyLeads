import { injectable } from 'inversify';
import { action, makeObservable } from 'mobx';
import { z } from 'zod';

export interface IUploadDocumentModalVM {
  uploadFormSchema: z.ZodObject<any>;
  upload: () => void;
}

@injectable()
class UploadDocumentModalVM implements IUploadDocumentModalVM {
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
  public upload = (): void => {
    // ... send request
  }
}

export default UploadDocumentModalVM;
