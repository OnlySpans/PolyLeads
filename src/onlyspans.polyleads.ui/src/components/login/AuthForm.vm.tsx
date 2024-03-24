import { injectable } from 'inversify';
import { action, makeObservable, observable } from 'mobx';

export interface IAuthFormVM {}

@injectable()
class AuthFormVM implements IAuthFormVM {
  @observable
  public isLoading: boolean = false;

  constructor() {
    makeObservable(this);
  }

  @action
  public setIsLoading = (isLoading: boolean) => {
    this.isLoading = isLoading;
  };
}

export default AuthFormVM;
