import { inject, injectable } from 'inversify';
import { action, flow, makeObservable, observable } from 'mobx';
import { z } from 'zod';
import type { IAuthApi } from '@/services/api/auth/authApi';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { ISignInPayload } from '@/data/abstractions/ISignInPayload';

export interface ISignInFormVM {
  isLoading: boolean;
  setIsLoading: (isLoading: boolean) => void;
  isPasswordShown: boolean;
  togglePasswordShown: () => void;
  signIn: (data: z.infer<any>) => void;
  schemaSignInForm: z.ZodObject<any>;
}

@injectable()
class SignInFormVm implements ISignInFormVM {
  @observable
  public isLoading: boolean = false;

  @observable
  public isPasswordShown: boolean = false;

  private formData: z.infer<typeof this.schemaSignInForm> | null = null;

  private readonly authApi: IAuthApi;

  constructor(@inject(ServiceSymbols.AuthApi) authApi: IAuthApi) {
    this.authApi = authApi;

    makeObservable(this);
  }

  @action
  public togglePasswordShown = () => {
    this.isPasswordShown = !this.isPasswordShown;
  }

  @action
  public setIsLoading = (isLoading: boolean) => {
    this.isLoading = isLoading;
  };

  @action
  public signIn = async (data: z.infer<typeof this.schemaSignInForm>) => {
    this.formData = data;
    this.sendSignInRequest();
  }

  @action.bound
  public sendSignInRequest = flow(function *(this: SignInFormVm) {
    if (this.formData === null)
      return;

    const payload: ISignInPayload = {
      username: this.formData.email,
      password: this.formData.password
    }

    try {
      this.formData = null;
      this.setIsLoading(true);
      yield this.authApi.signIn(payload);
    } finally {
      this.setIsLoading(false);
    }
  });

  public readonly schemaSignInForm: z.ZodObject<any> = z
    .object({
      email: z
        .string({ required_error: 'Поле должно быть заполнено' })
        .min(4, 'Имя должно содержать не менее 4 символов'),
      password: z
        .string({ required_error: 'Поле должно быть заполнено' })
        .min(6, 'Пароль должен содержать не менее 6 символов'),
    })

}

export default SignInFormVm;
