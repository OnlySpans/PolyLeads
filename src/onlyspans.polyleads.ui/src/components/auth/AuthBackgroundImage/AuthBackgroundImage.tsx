import React from 'react';

const AuthBackgroundImage: React.FC<{}> = () => {
  return (
    <div className='relative hidden h-screen flex-col p-12 text-white lg:flex'>
      <div className='absolute z-10 inset-0 bg-gradient-to-t from-zinc-900/75 to-80%'></div>
      <div
        className='absolute inset-0 bg-cover h-screen bg-center bg-no-repeat'
        style={{
          backgroundImage: 'url(/polytech.jpg)',
        }}
      ></div>

      <div className='relative z-20 mt-auto'>
        <blockquote className='space-y-2'>
          <p className='text-5xl'>PolyLeads</p>
          <footer className='text-sm'>Сайт для профоргов и старост</footer>
        </blockquote>
      </div>
    </div>
  );
};

export default AuthBackgroundImage;