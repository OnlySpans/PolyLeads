import { FC } from 'react';
import {
  Carousel,
  CarouselContent,
  CarouselItem,
  CarouselNext,
  CarouselPrevious,
} from '@/components/ui/carousel';
import { Card, CardContent, CardHeader, CardTitle } from '@/components/ui/card';
import { requestExamplesData } from '@/components/chat-bot/request-examples-cards/request-examples.data';
import Autoplay from 'embla-carousel-autoplay';
import useGet from '@/hooks/useGet';
import { IRequestFormVM } from '@/components/chat-bot/request-form/request-form.vm';
import ServiceSymbols from '@/data/constant/ServiceSymbols';

const RequestExamplesCards: FC = () => {
  const vm = useGet<IRequestFormVM>(ServiceSymbols.IRequestFormVM);

  return (
    <Carousel
      opts={{
        align: 'start',
      }}
      plugins={[
        Autoplay({
          delay: 2000,
        }),
      ]}
      className='lg:w-[75%] sm:w-[70%] w-[50%]'
    >
      <CarouselContent>
        {requestExamplesData.map((example, index) => (
          <CarouselItem key={index} className='sm:basis-1/2 lg:basis-1/3'>
            <div className='p-1'>
              <Card
                className='bg-muted hover:bg-muted-foreground/25 cursor-pointer max-h-[30%]'
                onClick={() => vm.sendExampleRequest(example.request)}
              >
                <CardHeader className='pb-2'>
                  <CardTitle>{example.icon}</CardTitle>
                </CardHeader>
                <CardContent className='flex min-h-32 items-start justify-center p-4'>
                  <p>{example.request}</p>
                </CardContent>
              </Card>
            </div>
          </CarouselItem>
        ))}
      </CarouselContent>
      <CarouselPrevious />
      <CarouselNext />
    </Carousel>
  );
};

export default RequestExamplesCards;