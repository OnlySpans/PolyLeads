'use client';

import { observer } from 'mobx-react-lite';
import { FC } from 'react';
import { ScrollArea } from '@/components/ui/scroll-area';
import { Avatar, AvatarFallback, AvatarImage } from '@/components/ui/avatar';
import moment from 'moment/moment';
import PromptSampleCards from '@/components/chat-bot/prompt-sample-cards/prompt-sample-cards';
import useGet from '@/hooks/useGet';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { IChatBotVM } from '@/components/chat-bot/chat-bot.vm';
import { Skeleton } from '@/components/ui/skeleton';
import PromptInput from "@/components/chat-bot/prompt-input/prompt-input";

const ChatBot: FC = () => {
  const vm = useGet<IChatBotVM>(ServiceSymbols.IChatBotVM);

  const MessageLoader: FC = () => {
    if (vm.isLoading) {
      return (
        <div className='my-4 flex items-end gap-2 justify-start'>
          <Avatar className='sm:block hidden'>
            <AvatarFallback>AI</AvatarFallback>
          </Avatar>
          <Skeleton className='h-[60px] sm:w-3/4 w-5/6 border rounded-md'/>
        </div>
      );
    }

    return <></>;
  };

  return (
    <div className='xl:w-1/2 md:w-2/3 px-4 w-full flex flex-col gap-4 items-center content-center justify-between'>
      {vm.messages.length !== 0 ? (
        <ScrollArea className='w-full h-screen rounded-md border md:px-4 px-2'>
          {vm.messages.map((message, index) => (
            <div
              className={`my-4 flex items-end gap-2 ${message.sender === 'bot' ? 'justify-start' : 'flex-row-reverse'}`}
              key={index}
            >
              {message.sender === 'bot' ? (
                <Avatar className='sm:block hidden'>
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
                  {moment(message.sentAt).format('HH:mm')}
                </p>
              </div>
            </div>
          ))}
          <MessageLoader />
          <div ref={vm.messagesEndRef} />
        </ScrollArea>
      ) : (
        <div className='w-full h-screen rounded-md border md:px-4 px-2'>
          <div className='flex h-full justify-center items-center content-center'>
            <PromptSampleCards />
          </div>
        </div>
      )}
      <div className='w-full'>
        <PromptInput />
      </div>
    </div>
  );
};

export default observer(ChatBot);
