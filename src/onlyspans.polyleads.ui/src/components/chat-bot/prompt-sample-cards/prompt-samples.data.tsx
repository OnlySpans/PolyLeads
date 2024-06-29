import { HandCoins, Home, LibraryBig, SquarePen, TreePalm } from 'lucide-react';

export interface IPromptSamplesData {
  prompt: string;
  icon: JSX.Element;
}

export const promptSamplesData: IPromptSamplesData[] = [
  {
    prompt: 'Какие виды стипендий доступны в университете?',
    icon: <HandCoins className='text-primary'/>,
  },
  {
    prompt: 'Как взять академический отпуск?',
    icon: <TreePalm className='text-[#0067FE]'/>,
  },
  {
    prompt: 'Как подать заявку на место в общежитии?',
    icon: <Home className='text-[#CDD42F]'/>,
  },
  {
    prompt: 'Как записаться в библиотеку?',
    icon: <LibraryBig className='text-[#FF8100]'/>,
  },
  {
    prompt: 'Как подать заявку на программу обмена?',
    icon: <SquarePen className='text-[#D82265]'/>,
  },
];