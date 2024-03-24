import 'reflect-metadata';
import type { Metadata } from 'next';
import './globals.css';
import { App } from '@/app/App';

export const metadata: Metadata = {
  title: 'PolyLeads',
  description: 'Сайт для профоргов и старост',
  authors: [{ name: 'OnlySpans', url: '/' }],
  icons: '/favicon.svg',
};

const RootLayout = ({ children }: Readonly<{ children: React.ReactNode }>) => {
  return (
    <html>
      <App children={children}/>
    </html> 
  );
};

export default RootLayout;