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

const RequestExamplesCards: FC = () => {
  return (
    <div>
      <Carousel
        opts={{
          align: 'start',
        }}
        plugins={[
          Autoplay({
            delay: 2000,
          }),
        ]}
        className='w-full'
      >
        <CarouselContent>
          {requestExamplesData.map((example, index) => (
            <CarouselItem key={index} className='md:basis-1/2 lg:basis-1/3'>
              <div>
                <Card className='bg-muted hover:bg-muted-foreground/25 cursor-pointer'>
                  <CardHeader>
                    <CardTitle>{example.icon}</CardTitle>
                  </CardHeader>
                  <CardContent className='flex aspect-square items-center justify-center p-6'>
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
    </div>
  );
};

export default RequestExamplesCards;