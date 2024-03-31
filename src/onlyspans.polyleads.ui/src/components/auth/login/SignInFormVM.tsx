import { injectable } from 'inversify';
import { action, makeObservable, observable } from 'mobx';
import { z } from 'zod';

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

  constructor() {
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
    this.setIsLoading(true);

    setTimeout(() => {
      this.setIsLoading(false);
    }, 3000);
  }

  get schemaSignInForm(): z.ZodObject<any> {
    return z.object({
      email: z
        .string({ required_error: 'Поле должно быть заполнено' })
        .min(4, 'Имя должно содержать не менее 4 символов'),
      password: z
        .string({ required_error: 'Поле должно быть заполнено' })
        .min(6, 'Пароль должен содержать не менее 6 символов'),
    })
  }
}

export default SignInFormVM;
