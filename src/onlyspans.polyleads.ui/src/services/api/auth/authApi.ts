import ApiClientBase from '@/services/api/api.base';
import Endpoints from '@/services/api/endpoints';

export default class AuthApi extends ApiClientBase {
  public readonly singin = async (
    username: string,
    password: string
  ): Promise<boolean> => {
    const url = Endpoints.Auth.signin();
    const response =
      await this.asyncRunner(() => this.api.post(url, { username, password }));
    return this.isSuccessfulStatusCode(response.status);
  };
}
