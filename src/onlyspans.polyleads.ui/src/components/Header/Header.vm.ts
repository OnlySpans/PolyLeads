import { inject, injectable } from 'inversify';
import { action, flow, makeObservable, observable } from 'mobx';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import type { IRoleApi } from '@/services/api/role/roleApi';

export interface IHeaderVM {
    isSignInButtonEnabled: boolean;
}

@injectable()
class HeaderVM implements IHeaderVM {
    @observable
    public isSignInButtonEnabled: boolean = true;

    private readonly roleApi: IRoleApi;
    
    constructor(
        @inject(ServiceSymbols.IRoleApi) roleApi: IRoleApi,
    ) {
        this.roleApi = roleApi;

        this.getRole();
        makeObservable(this);
    }
    
    @action.bound
    public getRole = flow(function *(this: HeaderVM) {
        try {
            const response = yield this.roleApi.getRole()

            if (response.role !== null){
                this.isSignInButtonEnabled = false;
            }
        } catch (e) {
            this.isSignInButtonEnabled = true;
        }
    });
}

export default HeaderVM;
