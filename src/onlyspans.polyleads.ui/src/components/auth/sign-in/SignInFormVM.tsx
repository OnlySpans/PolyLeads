import { inject, injectable } from 'inversify';
import { action, flow, makeObservable, observable } from 'mobx';
import { z } from 'zod';
import type { IAuthApi } from '@/services/api/auth/authApi';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { ISignInPayload } from '@/data/abstractions/ISignInPayload';
import { useRouter } from 'next/navigation';
import {toast} from '@/components/ui/use-toast';

export interface ISignInFormVM {
  isLoading: boolean;
  setIsLoading: (isLoading: boolean) => void;
  isPasswordShown: boolean;
  togglePasswordShown: () => void;
  signIn: (data: z.infer<any>) => void;
  schemaSignInForm: z.ZodObject<any>;
}

@injectable()
class SignInFormVM implements ISignInFormVM {
  @observable
  public isLoading: boolean = false;

  @observable
  public isPasswordShown: boolean = false;

  private formData: z.infer<typeof this.schemaSignInForm> | null = null;

  private readonly authApi: IAuthApi;

  private readonly router = useRouter();
  
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
  public sendSignInRequest = flow(function *(this: SignInFormVM) {
    if (this.formData === null)
      return;
    
    const payload: ISignInPayload = {
      username: this.formData.username,
      password: this.formData.password
    }

    try {
      this.formData = null;
      this.setIsLoading(true);
      yield this.authApi.signIn(payload);
      toast({
        title: "Вход выполнен",
        description: "Добро пожаловать! Вы успешно вошли в свою учетную запись.",
      })
      this.router.push('/');
    } finally {
      this.setIsLoading(false);
    }
  });

  public readonly schemaSignInForm: z.ZodObject<any> = z
    .object({
      username: z
        .string({ required_error: 'Поле должно быть заполнено' })
        .min(4, 'Имя должно содержать не менее 4 символов'),
      password: z
        .string({ required_error: 'Поле должно быть заполнено' })
        .min(6, 'Пароль должен содержать не менее 6 символов'),
    })
}

export default SignInFormVM;
