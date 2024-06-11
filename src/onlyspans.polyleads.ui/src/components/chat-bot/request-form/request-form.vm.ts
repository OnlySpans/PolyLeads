import { injectable } from 'inversify';
import { action, makeObservable, observable } from 'mobx';

export interface IRequestFormVM {
  value: string;
  setValue: (value: string) => void;
}

@injectable()
class RequestFormVM implements IRequestFormVM {
  @observable
  public value: string = ''

  constructor() {
    makeObservable(this);
  }

  @action
  public setValue = (value: string) => {
    this.value = value
  }
}

export default RequestFormVM;
