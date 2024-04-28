import React from 'react';
import { Settings2 } from 'lucide-react';
import { Button } from '@/components/ui/button';
import { Table } from '@tanstack/react-table';
import {
  DropdownMenu,
  DropdownMenuCheckboxItem,
  DropdownMenuContent,
  DropdownMenuTrigger,
} from '@/components/ui/dropdown-menu';

interface IDataTableViewOptionsProps<TData> {
  table: Table<TData>;
}

const DataTableViewOptions: React.FC<any> = <TData extends any>({
  table,
}: IDataTableViewOptionsProps<TData>) => {
  return (
    <>
      <DropdownMenu>
        <DropdownMenuTrigger asChild>
          <Button variant='outline' className='h-8 px-4'>
            <Settings2 className='mr-2 size-4' />
            Вид
          </Button>
        </DropdownMenuTrigger>
        <DropdownMenuContent align='end'>
          {table
            .getAllColumns()
            .filter((column) => column.getCanHide())
            .map((column) => {
              return (
                <DropdownMenuCheckboxItem
                  key={column.id}
                  checked={column.getIsVisible()}
                  onCheckedChange={(value) =>
                    column.toggleVisibility(value)
                  }
                >
                  {column.columnDef.meta!.name}
                </DropdownMenuCheckboxItem>
              );
            })}
        </DropdownMenuContent>
      </DropdownMenu>
    </>
  );
};

export default DataTableViewOptions;
