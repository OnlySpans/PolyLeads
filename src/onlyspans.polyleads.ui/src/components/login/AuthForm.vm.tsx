import { injectable } from 'inversify';
import { action, makeObservable, observable } from 'mobx';
import React from 'react';
import { z } from 'zod';

export interface IAuthFormVM {
  isLoading: boolean;
  setIsLoading: (isLoading: boolean) => void;
  isPasswordShown: boolean;
  togglePasswordShown: () => void;
  login: (event: React.SyntheticEvent) => void;
  formSchema: z.ZodObject<any>;
}

@injectable()
class AuthFormVM implements IAuthFormVM {
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

  public formSchema = z.object({
    email: z
      .string({ required_error: 'Поле должно быть заполнено' })
      .min(4, 'Имя должно содержать не менее 4 символов'),
    password: z
      .string({ required_error: 'Поле должно быть заполнено' })
      .min(6, 'Пароль должен содержать не менее 6 символов'),
  });
}

export default AuthFormVM;
