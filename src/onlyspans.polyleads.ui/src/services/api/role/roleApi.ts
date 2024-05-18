import ApiClientBase from '@/services/api/api.base';
import Endpoints from '@/services/api/endpoints';

export interface IRoleApi {
    getRole(): Promise<string>;
}

export class RoleApi
    extends ApiClientBase
    implements IRoleApi {
    public readonly getRole = async (): Promise<string> => {
        const url = Endpoints.Role.getRole();
        console.log(url)
        
        const response = await this.asyncRunner(() => this.api.get(url));
        return response.data;
    };
}
