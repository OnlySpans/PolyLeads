import { buttonVariants } from '@/components/ui/button';
import { cn } from '@/lib/utils';
import Link from 'next/link';
import { ThemeSwitchButton } from '@/components/ui/ThemeSwitchButton';

const Home = () => {
  return (
    <main className='flex min-h-screen flex-col items-center justify-between p-24'>
      <Link
        href={'/login'}
        className={cn(buttonVariants({ variant: 'default' }))}
      >
        Войти
      </Link>
      <ThemeSwitchButton />
    </main>
  );
};

export default Home;