import { buttonVariants } from '@/components/ui/button';
import { cn } from '@/lib/utils';
import Link from 'next/link';

export default function Home() {
  return (
    <main className='flex min-h-screen flex-col items-center justify-between p-24'>
      <Link href='/login' className={cn(buttonVariants({ variant: 'default' }))}>
        Login
      </Link>
    </main>
  );
}
