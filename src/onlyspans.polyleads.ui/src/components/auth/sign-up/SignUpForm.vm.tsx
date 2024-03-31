import { injectable } from 'inversify';
import { action, makeObservable, observable } from 'mobx';
import React from 'react';
import { z, ZodEffects } from 'zod';

export interface ISignUpFormVM {
  isLoading: boolean;
  setIsLoading: (isLoading: boolean) => void;
  isPasswordShown: boolean;
  togglePasswordShown: () => void;
  login: (event: React.SyntheticEvent) => void;
  schemaSignUpForm: ZodEffects<z.ZodObject<any>>;
}

@injectable()
class SignUpFormVM implements ISignUpFormVM {
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
  public login = async (event: React.SyntheticEvent) => {
    event.preventDefault();
    this.setIsLoading(true);

    setTimeout(() => {
      this.setIsLoading(false);
    }, 3000);
  }

  get schemaSignUpForm(): ZodEffects<z.ZodObject<any>> {
    return z.object({
      username: z
        .string({ required_error: 'Поле должно быть заполнено' })
        .min(4, 'Имя должно содержать не менее 4 символов'),
      email: z
        .string({ required_error: 'Поле должно быть заполнено' })
        .email('Некорректный ввод почты'),
      password: z
        .string({ required_error: 'Поле должно быть заполнено' })
        .min(6, 'Пароль должен содержать не менее 6 символов'),
      confirmPassword: z
        .string({ required_error: 'Поле должно быть заполнено' })
        .min(6, 'Пароль должен содержать не менее 6 символов'),
    }).refine(data => data.password === data.confirmPassword, {
      message: 'Пароли должны совпадать',
      path: ['confirmPassword']
    })
  }
}

export default SignUpFormVM;