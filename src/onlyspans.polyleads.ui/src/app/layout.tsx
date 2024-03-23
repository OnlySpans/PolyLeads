import type { Metadata } from 'next';
import { Inter } from 'next/font/google';
import './globals.css';

const inter = Inter({ subsets: ['latin', 'cyrillic'] });

export const metadata: Metadata = {
  title: 'PolyLeads',
  description: 'Сайт для профоргов и старост',
  authors: [{ name: "OnlySpans", url: "/" }],
  icons: '/favicon.svg'
};

const RootLayout = ({ children }: Readonly<{ children: React.ReactNode }>) => {
  return (
    <html>

      <body className={inter.className}>{children}</body>
    </html>
  );
};

export default RootLayout;