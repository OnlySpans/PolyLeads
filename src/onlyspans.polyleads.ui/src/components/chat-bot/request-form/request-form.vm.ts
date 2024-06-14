import { injectable } from 'inversify';
import { action, makeObservable, observable } from 'mobx';

export interface IRequestFormVM {
  value: string;
  setValue: (value: string) => void;
  sendRequest: () => void;
  sendExampleRequest: (request: string) => void;
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

  @action
  public sendRequest = () => {
    this.value = ''
  }

  @action
  public sendExampleRequest = (request: string) => {
    this.value = request
    this.sendRequest() 
  }
}

export default RequestFormVM;
