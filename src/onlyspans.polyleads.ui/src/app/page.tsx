'use client';

import Header from '@/components/Header/Header';
import DocumentsTable from '@/components/DocumentsManager/DocumentsTable/DocumentsTable';

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
        <div>
          <DocumentsTable />
        </div>
      </div>
    </>
  );
};

export default Home;