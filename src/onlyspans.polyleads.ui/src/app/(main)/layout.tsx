import 'reflect-metadata';
import Header from '@/components/header/header';

const RootLayout = ({ children }: Readonly<{ children: React.ReactNode }>) => {
  return (
    <div>
      <Header />
      {children}
    </div>
  );
};

export default RootLayout;
