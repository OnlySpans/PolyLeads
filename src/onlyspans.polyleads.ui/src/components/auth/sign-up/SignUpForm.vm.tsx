import { inject, injectable } from 'inversify';
import { action, flow, makeObservable, observable } from 'mobx';
import { z, ZodEffects } from 'zod';
import type { IAuthApi } from '@/services/api/auth/authApi';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { ISignUpPayload } from '@/data/abstractions/ISignUpPayload';
import { useRouter } from 'next/navigation';
import { toast } from '@/components/ui/use-toast';

export interface ISignUpFormVM {
  isLoading: boolean;
  setIsLoading: (isLoading: boolean) => void;
  isPasswordShown: boolean;
  togglePasswordShown: () => void;
  signUp: (data: z.infer<any>) => void;
  schemaSignUpForm: ZodEffects<z.ZodObject<any>>;
}

@injectable()
class SignUpFormVM implements ISignUpFormVM {
  @observable
  public isLoading: boolean = false;

  @observable
  public isPasswordShown: boolean = false;

  private formData: z.infer<typeof this.schemaSignUpForm> | null = null;

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
  public signUp = async (data: z.infer<typeof this.schemaSignUpForm>) => {
    this.formData = data;
    this.sendSignUpRequest();
  }

  @action.bound
  public sendSignUpRequest = flow(function *(this: SignUpFormVM) {
    if (this.formData === null)
      return;

    const payload: ISignUpPayload = {
      firstName: this.formData.firstName,
      lastName: this.formData.lastName,
      password: this.formData.password,
      username: this.formData.username
    }

    try {
      this.formData = null;
      this.setIsLoading(true);
      yield this.authApi.signUp(payload);
      toast({
        title: "Регистрация успешно завершена!",
        description: "Поздравляем! Ваша учетная запись успешно создана. Теперь вы можете пользоваться " +
            "всеми возможностями нашего сервиса. Добро пожаловать!",
      })
      this.router.push('/');
    } catch (e) {
      toast({
        variant: "destructive",
        title: "Ошибка при регистрации",
        description: "Пожалуйста, проверьте введенные данные и попробуйте снова. Если проблема не устранена, повторите попытку немного позже.",
      })
    } finally {
      this.setIsLoading(false);
    }
  });

  public readonly schemaSignUpForm: ZodEffects<z.ZodObject<any>> = z
    .object({
      firstName: z
        .string({ required_error: 'Поле должно быть заполнено' })
        .min(2, 'Имя должно содержать не менее 2 символов')
        .regex(/^[a-zA-Zа-яА-Я]+$/, {
          message: 'Имя не может содержать цифры или спецсимволы'
        }),
      lastName: z
        .string({ required_error: 'Поле должно быть заполнено' })
        .min(2, 'Фамилия должна содержать не менее 2 символов')
        .regex(/^[a-zA-Zа-яА-Я]+$/, {
          message: 'Фамилия не может содержать цифры или спецсимволы'
        }),
      patronymic: z
        .string()
        .regex(/^[a-zA-Zа-яА-Я]+$/, {
          message: 'Отчество не может содержать цифры или спецсимволы'
        })
        .optional(),
      username: z
        .string({ required_error: 'Поле должно быть заполнено' })
        .min(4, 'Никнейм должен содержать не менее 4 символов')
        .regex(/^[a-zA-Zа-яА-Я0-9]+$/, {
          message: 'Никнейм не может содержать спецсимволы'
        })
        .toLowerCase(),
      email: z
        .string({ required_error: 'Поле должно быть заполнено' })
        .email('Некорректный ввод почты'),
      password: z
        .string({ required_error: 'Поле должно быть заполнено' })
        .min(6, 'Пароль должен содержать не менее 6 символов')
        .regex(/^\S*$/, {
          message: 'Пароль не может содержать пробелы'
        }),
      confirmPassword: z.string({ required_error: 'Поле должно быть заполнено' })
    }).refine(data => data.password === data.confirmPassword, {
      message: 'Пароли должны совпадать',
      path: ['confirmPassword']
    })
}

export default SignUpFormVM;
