import ApiClientBase from '@/services/api/api.base';
import Endpoints from '@/services/api/endpoints';
import { INewDocument } from '@/data/abstractions/INewDocument';
import { IDocument } from '@/data/abstractions/IDocument';

export interface IDocumentApi {
  create(payload: INewDocument): Promise<boolean>;
  query(description: string): Promise<IDocument>;
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

  public readonly query = async (description: string): Promise<IDocument> => {
    const url = Endpoints.Document.query(description);
    const response = await this.asyncRunner(() => this.api.get(url));
    return response.data;
  };
}
