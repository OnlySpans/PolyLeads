'use client';

import Header from '@/components/Header/Header';
import DocumentsTable from '@/components/DocumentsManager/DocumentsTable/DocumentsTable';

const Home = () => {
  return (
    <>
      <Header />
      <div className='h-full flex-1 flex-col sm:p-6 px-0 py-4 flex '>
        {/*<div className='container flex max-w-screen-2xl items-center'>*/}
        {/*  <div>*/}
        {/*    <h2 className='text-2xl font-bold tracking-tight'>*/}
        {/*      Хранилище документов*/}
        {/*    </h2>*/}
        {/*    <p className='text-muted-foreground'>*/}
        {/*      Здесь собраны все важные документы:)*/}
        {/*      организаций*/}
        {/*    </p>*/}
        {/*  </div>*/}
        {/*</div>*/}
        <div className='container md:px-8 px-4 flex max-w-screen-2xl items-center'>
          <DocumentsTable />
        </div>
      </div>
    </>
  );
};

export default Home;