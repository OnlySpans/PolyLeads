import Link from 'next/link';
import { cn } from '@/lib/utils';
import { buttonVariants } from '@/components/ui/button';
import AuthForm from '@/components/auth/login/SignInForm';
import { ThemeSwitchButton } from '@/components/ui/ThemeSwitchButton';
import AuthBackgroundImage from '@/components/auth/AuthBackgroundImage';

const AuthenticationPage = () => {
  return (
    <div className='bg-fixed container relative hidden h-screen flex-col items-center justify-center min-[300px]:grid lg:max-w-none lg:grid-cols-2 lg:px-0'>
      <Link
        href={'/auth/sign-up'}
        className={cn(
          buttonVariants({ variant: 'ghost' }),
          'absolute right-4 top-4 md:right-8 md:top-8',
        )}
      >
        Регистрация
      </Link>
      <div className={'absolute right-4 bottom-4 md:right-6 md:bottom-6'}>
        <ThemeSwitchButton />
      </div>
      <AuthBackgroundImage />
      <div className='lg:p-8'>
        <div className='mx-auto flex w-full flex-col justify-center space-y-6 sm:w-[350px]'>
          <div className='flex flex-col space-y-2 text-center'>
            <h1 className='text-2xl font-semibold tracking-tight'>Вход</h1>
            <p className='text-sm text-muted-foreground'>
              Используйте почту или имя пользователя
            </p>
          </div>
          <AuthForm />
        </div>
      </div>
    </div>
  );
};

export default AuthenticationPage;