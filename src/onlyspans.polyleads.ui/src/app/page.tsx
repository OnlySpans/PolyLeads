'use client';

import Header from '@/components/Header/Header';
import DocumentsTable from '@/components/documents/DocumentsTable/DocumentsTable';

const Home = () => {
  return (
    <>
      <Header />
      <div className='h-full flex-1 flex-col sm:p-6 px-0 py-4 flex '>
        <div className='container md:px-8 px-4 flex max-w-screen-2xl items-center'>
          <DocumentsTable />
        </div>
      </div>
    </>
  );
};

export default Home;