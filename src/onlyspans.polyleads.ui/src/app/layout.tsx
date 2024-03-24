import 'reflect-metadata';

import type { Metadata } from 'next';
import { Inter } from 'next/font/google';
import './globals.css';
import DependencyContainer, {
  createDependencyContainer,
} from '@/contexts/dependencyContainer';
import { Container } from 'inversify';

const inter = Inter({ subsets: ['latin', 'cyrillic'] });

export const metadata: Metadata = {
  title: 'PolyLeads',
  description: 'Сайт для профоргов и старост',
  authors: [{ name: "OnlySpans", url: "/" }],
  icons: '/favicon.svg'
};

const RootLayout = ({ children }: Readonly<{ children: React.ReactNode }>) => {
  const dependencyContainer: Container = createDependencyContainer();
  return (
    <html>
      <DependencyContainer.Provider value={dependencyContainer}>
        <body className={inter.className}>{children}</body>
      </DependencyContainer.Provider>
    </html> 
  );
};

export default RootLayout;