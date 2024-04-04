import Link from 'next/link';
import { cn } from '@/lib/utils';
import { Button, buttonVariants } from '@/components/ui/button';
import { ThemeSwitchButton } from '@/components/ui/ThemeSwitchButton';
import { Cookie, Settings2 } from 'lucide-react';
import { Input } from '@/components/ui/input';
import { Table, TableBody, TableHeader, TableRow } from '@/components/ui/table';

const Home = () => {
  return (
    <>
      {/*TODO: вынести в компонент*/}
      <header className='sticky top-0 z-50 w-full border-b border-border/70 bg-background/95'>
        <div className='container flex h-14 max-w-screen-2xl items-center'>
          <div className='flex gap-4'>
            <Cookie className='text-primary ml-1' />
            <nav className='flex items-center gap-4 text-sm'>
              <Link
                href='/'
                className='text-sm font-medium transition-colors hover:text-primary'
              >
                Something
              </Link>
              <Link
                href='/'
                className='text-sm font-medium text-muted-foreground transition-colors hover:text-primary'
              >
                Settings
              </Link>
            </nav>
          </div>
          <div className='flex flex-1 items-center space-x-2 justify-end'>
            <Link
              href={'/auth/sign-in'}
              className={cn(
                buttonVariants({
                  variant: 'default',
                }),
              )}
            >
              Войти
            </Link>
            <ThemeSwitchButton />
          </div>
        </div>
      </header>
      <div className='hidden h-full flex-1 flex-col space-y-8 p-8 md:flex'>
        <div className='flex items-center justify-between space-y-2'>
          {/*<div>*/}
          {/*  <h2 className='text-2xl font-bold tracking-tight'>Welcome back!</h2>*/}
          {/*  <p className='text-muted-foreground'>Работа с файлами</p>*/}
          {/*</div>*/}
          <div className='flex items-center space-x-2'>{/*<UserNav />*/}</div>
        </div>
        <div className={'space-y-4'}>
          <div className='flex items-center justify-between'>
            <div className='flex flex-1 items-center space-x-2'>
              <Input
                placeholder='Введите ключевые слова'
                className='h-8 w-[150px] lg:w-[250px]'
              />
              <Button variant='outline' className='h-8 px-4'>
                Добавить файл
              </Button>
            </div>
            <Button variant='outline' className='h-8 px-4'>
              <Settings2 className='mr-2 size-4' />
              Вид
            </Button>
          </div>
        </div>
        {/*<DataTable data={tasks} columns={columns} />*/}

        <div className='rounded-md border'>
          <Table>
            <TableHeader>
              <TableRow key={1}>Some Data</TableRow>
            </TableHeader>
            <TableBody>
              <TableRow key={1}>Some Data</TableRow>
              <TableRow key={2}>Some Data</TableRow>
              <TableRow key={3}>Some Data</TableRow>
            </TableBody>
          </Table>
        </div>
      </div>
    </>
  );
};

export default Home;