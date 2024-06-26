import { FC } from 'react';
import { Avatar, AvatarFallback } from '@/components/ui/avatar';
import { Skeleton } from '@/components/ui/skeleton';
import useGet from '@/hooks/useGet';
import { IChatBotVM } from '@/components/chat-bot/chat-bot.vm';
import ServiceSymbols from '@/data/constant/ServiceSymbols';

const MessageLoader: FC = () => {
  const vm = useGet<IChatBotVM>(ServiceSymbols.IChatBotVM);

  if (vm.isLoading) {
    return (
      <div className='my-4 flex items-end gap-2 justify-start'>
        <Avatar className='sm:block hidden'>
          <AvatarFallback>AI</AvatarFallback>
        </Avatar>
        <Skeleton className='h-[60px] sm:w-3/4 w-5/6 border rounded-md' />
      </div>
    );
  }

  return <></>;
}

export default MessageLoader;