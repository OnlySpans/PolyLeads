import { Avatar, AvatarFallback } from '@/components/ui/avatar';
import moment from 'moment';
import { FC } from 'react';
import { IMessage } from '@/data/abstractions/IMessage';

interface IUserMessageProps {
  message: IMessage,
  index: number,
}

const UserMessage: FC<IUserMessageProps> = ({ message, index }) => {
  return (
    <div
      className={'my-4 flex items-end gap-2 flex-row-reverse'}
      key={index}
    >
      <Avatar className='sm:block hidden'>
        <AvatarFallback>{'^-^'}</AvatarFallback>
      </Avatar>
      <div className='sm:w-3/4 w-5/6 max-w-full bg-accent p-4 border rounded-md'>
        <p className='hyphens-auto break-words max-w-[40rem]'>
          {message.text}
        </p>
        <p className='text-muted-foreground text-right text-xs mb-[-8px] mr-[-4px]'>
          {moment(message.sentAt).format('HH:mm')}
        </p>
      </div>
    </div>
  )
}

export default UserMessage;