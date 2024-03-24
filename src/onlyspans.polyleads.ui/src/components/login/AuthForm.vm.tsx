import { inject, injectable } from 'inversify';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { action, makeObservable, observable } from 'mobx';

export interface IAuthFormVM {}

@injectable()
class AuthFormVM implements IAuthFormVM {
  @observable
  public isLoading: boolean = false;

  constructor(@inject(ServiceSymbols.IAuthFormVM) auth: IAuthFormVM) {
    makeObservable(this);
  }

  @action
  public setIsLoading = (isLoading: boolean) => {
    this.isLoading = isLoading;
  };
}

export default AuthFormVM;
