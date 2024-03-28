import { cn } from '@/lib/utils';
import { buttonVariants } from '@/components/ui/button';
import Link from 'next/link';

const SignUpPage = () => {
  return (
    <>
      <Link
        href='/login'
        className={cn(
          buttonVariants({ variant: 'ghost' }),
          'absolute right-4 top-4 md:right-8 md:top-8',
        )}
      >
        Войти
      </Link>
    </>
  );
};

export default SignUpPage;