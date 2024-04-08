import { Button } from '@/components/ui/button';
import { Input } from '@/components/ui/input';
import Header from '@/components/Header/Header';
import { Table, TableBody, TableHeader, TableRow } from '@/components/ui/table';
import DataTableViewOptions from '@/components/FileManager/DataTableViewOptions/DataTableViewOptions';

const Home = () => {
  return (
    <>
      {/*TODO: вынести в компонент*/}
      <Header />
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

            <DataTableViewOptions />
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