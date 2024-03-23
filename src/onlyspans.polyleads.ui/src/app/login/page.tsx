import Link from 'next/link';
import { cn } from '@/lib/utils';
import { AuthForm } from '@/components/login/AuthForm';
import { buttonVariants } from '@/components/ui/button';

export default function AuthenticationPage() {
  return (
    <>
      <div className='bg-fixed container relative hidden h-screen flex-col items-center justify-center min-[300px]:grid lg:max-w-none lg:grid-cols-2 lg:px-0'>
        <Link
          href='/'
          className={cn(
            buttonVariants({ variant: 'ghost' }),
            'absolute right-4 top-4 md:right-8 md:top-8',
          )}
        >
          Sign Up
        </Link>
        <div className='relative hidden h-screen flex-col p-12 text-white lg:flex'>
          <div className='absolute z-10 inset-0 bg-gradient-to-t from-zinc-900/75 to-80%'></div>
          <div
            className='absolute inset-0 bg-cover h-screen bg-center bg-no-repeat'
            style={{
              backgroundImage: 'url(/polytech.jpg)',
              filter: 'grayscale(1)',
            }}
          ></div>

          <div className='relative z-20 mt-auto'>
            <blockquote className='space-y-2'>
              <p className='text-5xl'>PolyLeads</p>
              <footer className='text-sm'>Сайт для профоргов и старост</footer>
            </blockquote>
          </div>
        </div>
        <div className='lg:p-8'>
          <div className='mx-auto flex w-full flex-col justify-center space-y-6 sm:w-[350px]'>
            <div className='flex flex-col space-y-2 text-center'>
              <h1 className='text-2xl font-semibold tracking-tight'>Вход</h1>
              <p className='text-sm text-muted-foreground'>
                Используйте email или имя пользователя
              </p>
            </div>
            <AuthForm />
          </div>
        </div>
      </div>
    </>
  );
}
