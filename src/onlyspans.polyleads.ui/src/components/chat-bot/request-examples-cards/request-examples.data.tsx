import { HandCoins, Home, LibraryBig, SquarePen, TreePalm } from 'lucide-react';

export interface IRequestExampleData {
  request: string;
  icon: JSX.Element;
}

export const requestExamplesData: IRequestExampleData[] = [
  {
    request: 'Какие виды стипендий доступны в университете?',
    icon: <HandCoins className='text-primary'/>,
  },
  {
    request: 'Как взять академический отпуск?',
    icon: <TreePalm className='text-[#0067FE]'/>,
  },
  {
    request: 'Как подать заявку на место в общежитии?',
    icon: <Home className='text-[#CDD42F]'/>,
  },
  {
    request: 'Как записаться в библиотеку?',
    icon: <LibraryBig className='text-[#FF8100]'/>,
  },
  {
    request: 'Как подать заявку на программу обмена?',
    icon: <SquarePen className='text-[#D82265]'/>,
  },
];