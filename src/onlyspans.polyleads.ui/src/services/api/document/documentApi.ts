import ApiClientBase from '@/services/api/api.base';
import Endpoints from '@/services/api/endpoints';
import { INewDocument } from '@/data/abstractions/INewDocument';

export interface IDocumentApi {
  create(payload: INewDocument): Promise<boolean>;
}

export class DocumentApi
  extends ApiClientBase
  implements IDocumentApi {

  public readonly create = async (
    payload: INewDocument
  ): Promise<boolean> => {
    const url = Endpoints.Document.create();
    const response = await this.asyncRunner(() => this.api.post(url, payload));
    return this.isSuccessfulStatusCode(response.status);
  };
}
