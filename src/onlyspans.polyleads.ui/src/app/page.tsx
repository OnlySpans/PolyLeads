'use client';

import Header from '@/components/Header/Header';
import DocumentsTable from '@/components/DocumentsManager/DocumentsTable/DocumentsTable';

const Home = () => {
  return (
    <>
      <Header />
      <div className='hidden h-full flex-1 flex-col space-y-8 p-8 md:flex'>
        {/*<div className='container flex max-w-screen-2xl items-center'>*/}
        {/*  <div>*/}
        {/*    <h2 className='text-2xl font-bold tracking-tight'>*/}
        {/*      Хранилище документов*/}
        {/*    </h2>*/}
        {/*    <p className='text-muted-foreground'>*/}
        {/*      Все важные документы для учебы и деятельности студенческих*/}
        {/*      организаций*/}
        {/*    </p>*/}
        {/*  </div>*/}
        {/*</div>*/}
        <div className={'container flex max-w-screen-2xl items-center'}>
          <DocumentsTable />
        </div>
      </div>
    </>
  );
};

export default Home;