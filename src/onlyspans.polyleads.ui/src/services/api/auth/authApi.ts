import ApiClientBase from '@/services/api/api.base';
import Endpoints from '@/services/api/endpoints';
import { ISignInPayload } from '@/data/abstractions/ISignInPayload';
import { ISignUpPayload } from '@/data/abstractions/ISignUpPayload';

export interface IAuthApi {
  signin(payload: ISignInPayload): Promise<boolean>;
  signup(payload: ISignUpPayload): Promise<boolean>;
}

export class AuthApi
  extends ApiClientBase
  implements IAuthApi {

  public readonly signin = async (
    { password, username }: ISignInPayload
  ): Promise<boolean> => {
    const url = Endpoints.Auth.signin();
    const response = await this.asyncRunner(
      () => this.api.post(url, { username, password }));
    return this.isSuccessfulStatusCode(response.status);
  };

  public readonly signup = async (payload: ISignUpPayload): Promise<boolean> => {
    const url = Endpoints.Auth.signup();
    const response = await this.asyncRunner(
      () => this.api.post(url, payload))
    return this.isSuccessfulStatusCode(response.status);
  };
}
