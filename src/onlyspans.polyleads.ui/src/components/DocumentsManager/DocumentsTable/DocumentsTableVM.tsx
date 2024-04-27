import { injectable } from 'inversify';
import { makeObservable } from 'mobx';

export interface IDocumentsTableVM {
  // data: IDocument[];
}

@injectable()
class DocumentsTableVM implements IDocumentsTableVM {
  constructor() {
    makeObservable(this);
  }

}

export default DocumentsTableVM;
