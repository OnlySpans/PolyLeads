import ApiClientBase from '@/services/api/api.base';
import Endpoints from '@/services/api/endpoints';

export interface IAuthApi {
  singin(username: string, password: string): Promise<boolean>;
}

export class AuthApi
  extends ApiClientBase
  implements IAuthApi {
  public readonly singin = async (
    username: string,
    password: string
  ): Promise<boolean> => {
    const url = Endpoints.Auth.signin();
    const response = await this.asyncRunner(
      () => this.api.post(url, { username, password }));
    return this.isSuccessfulStatusCode(response.status);
  };
}
