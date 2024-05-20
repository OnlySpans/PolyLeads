import ApiClientBase from '@/services/api/api.base';
import Endpoints from '@/services/api/endpoints';

export interface IUserRoleApi {
  getUserRole(): Promise<string>;
}

export class UserRoleApi
    extends ApiClientBase
    implements IUserRoleApi {
    public readonly getUserRole = async (): Promise<string> => {
        const url = Endpoints.Role.getUserRole();
        const response = await this.asyncRunner(() => this.api.get(url));
        return response.data;
    };
}
