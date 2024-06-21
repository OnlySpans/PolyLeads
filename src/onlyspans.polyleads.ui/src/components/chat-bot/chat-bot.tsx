'use client';

import { observer } from 'mobx-react-lite';
import { FC } from 'react';
import RequestForm from '@/components/chat-bot/request-form/request-form';
import { ScrollArea } from '@/components/ui/scroll-area';
import { Avatar, AvatarFallback, AvatarImage } from '@/components/ui/avatar';
import moment from 'moment/moment';
import RequestExamplesCards from '@/components/chat-bot/request-examples-cards/request-examples-cards';
import useGet from '@/hooks/useGet';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { IChatBotVM } from '@/components/chat-bot/chat-bot.vm';
import { Skeleton } from '@/components/ui/skeleton';
import { LoaderCircle } from 'lucide-react';

const ChatBot: FC = () => {
  const vm = useGet<IChatBotVM>(ServiceSymbols.IChatBotVM);

  return (
    <div className='xl:w-1/2 md:w-2/3 px-4 w-full flex flex-col items-center content-center justify-between'>
      {vm.messages.length !== 0 ? (
        <ScrollArea className='w-full h-screen rounded-md border md:px-4 px-2 mb-6'>
          {vm.messages.map((message) => (
            <div
              className={`my-4 flex items-end gap-2 ${message.type === 'bot' ? 'justify-start' : 'flex-row-reverse'}`}
              key={message.id}
            >
              {message.type === 'bot' ? (
                <Avatar className='sm:block hidden'>
                  <AvatarImage src='https://github.asdasdcom/shadcn.png' />
                  <AvatarFallback>AI</AvatarFallback>
                </Avatar>
              ) : (
                <Avatar className='sm:block hidden'>
                  <AvatarImage src='' />
                  <AvatarFallback>{'^-^'}</AvatarFallback>
                </Avatar>
              )}
              <div className='sm:w-3/4 w-5/6 max-w-full bg-accent p-4 border rounded-md'>
                <p className='hyphens-auto break-words max-w-[40rem]'>
                  {message.text}
                </p>
                <p className='text-muted-foreground text-right text-xs mb-[-8px] mr-[-4px]'>
                  {moment(message.timestamp).format('HH:mm')}
                </p>
              </div>
            </div>
          ))}
          {vm.isLoading ? (
            <div className='my-4 flex items-end gap-2 justify-start'>
              <Avatar className='sm:block hidden animate-spin'>
                <AvatarFallback>
                  <LoaderCircle className='text-primary' />
                </AvatarFallback>
              </Avatar>
              <Skeleton className='h-[60px] sm:w-3/4 w-5/6 border rounded-md' />
            </div>
          ) : (
            <></>
          )}
          <div ref={vm.messagesEndRef} />
        </ScrollArea>
      ) : (
        <div className='w-full h-screen rounded-md border md:px-4 px-2 mb-6'>
          <div className='flex h-full justify-center items-center content-center'>
            <RequestExamplesCards />
          </div>
        </div>
      )}
      <div className='w-full'>
        <RequestForm />
      </div>
    </div>
  );
};

export default observer(ChatBot);
