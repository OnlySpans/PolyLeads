import ApiClientBase from '@/services/api/api.base';
import Endpoints from '@/services/api/endpoints';
import { ISignInPayload } from '@/data/abstractions/ISignInPayload';
import { ISignUpPayload } from '@/data/abstractions/ISignUpPayload';

export interface IAuthApi {
  signIn(payload: ISignInPayload): Promise<boolean>;
  signUp(payload: ISignUpPayload): Promise<boolean>;
}

export class AuthApi
  extends ApiClientBase
  implements IAuthApi {

  public readonly signIn = async (
    { password, username }: ISignInPayload
  ): Promise<boolean> => {
    const url = Endpoints.Auth.signIn();
    const response = await this.asyncRunner(
      () => this.api.post(url, { username, password }));
    return this.isSuccessfulStatusCode(response.status);
  };

  public readonly signUp = async (payload: ISignUpPayload): Promise<boolean> => {
    const url = Endpoints.Auth.signUp();
    const response = await this.asyncRunner(
      () => this.api.post(url, payload))
    return this.isSuccessfulStatusCode(response.status);
  };
}
