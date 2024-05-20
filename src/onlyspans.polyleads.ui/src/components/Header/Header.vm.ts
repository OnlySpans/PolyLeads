import { inject, injectable } from 'inversify';
import { action, flow, makeObservable, observable } from 'mobx';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import type { IUserRoleApi } from '@/services/api/role/userRoleApi';

export interface IHeaderVM {
  isSignInButtonEnabled: boolean;
}

@injectable()
class HeaderVM implements IHeaderVM {
  @observable
  public isSignInButtonEnabled: boolean = true;

  private readonly userRoleApi: IUserRoleApi;

  constructor(@inject(ServiceSymbols.IRoleApi) userRoleApi: IUserRoleApi) {
    this.userRoleApi = userRoleApi;

    this.isUserAuthorised();
    makeObservable(this);
  }

  @action.bound
  public isUserAuthorised = flow(function* (this: HeaderVM) {
    try {
      const response = yield this.userRoleApi.getUserRole();

      if (response.role !== null) {
        this.isSignInButtonEnabled = false;
      }
    } catch (e) {
      this.isSignInButtonEnabled = true;
    }
  });
}

export default HeaderVM;
