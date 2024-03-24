'use client';

import 'reflect-metadata';
import { Inter } from 'next/font/google';
import './globals.css';
import DependencyContainer, {
  createDependencyContainer,
} from '@/contexts/dependencyContainer';
import { Container } from 'inversify';

const inter = Inter({ subsets: ['latin', 'cyrillic'] });

export const App = ({ children }: Readonly<{ children: React.ReactNode }>) => {
  const dependencyContainer: Container = createDependencyContainer();
  
  return (
    <DependencyContainer.Provider value={dependencyContainer}>
      <body className={inter.className}>{children}</body>
    </DependencyContainer.Provider>
  )
}