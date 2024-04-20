'use client';

import useGet from '@/hooks/useGet';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { IDocumentsTableVM } from '@/components/DocumentsManager/DocumentsTable/DocumentsTableVM';
import React from 'react';
import { observer } from 'mobx-react-lite';

import {
  ColumnDef,
  ColumnFiltersState,
  flexRender,
  getCoreRowModel,
  getFilteredRowModel,
  getPaginationRowModel,
  getSortedRowModel,
  SortingState,
  useReactTable,
  VisibilityState,
} from '@tanstack/react-table';

import { Button } from '@/components/ui/button';
import {
  DropdownMenu,
  DropdownMenuCheckboxItem,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from '@/components/ui/dropdown-menu';
import { Input } from '@/components/ui/input';
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from '@/components/ui/table';
import { Checkbox } from '@/components/ui/checkbox';
import { ChevronsUpDown, Ellipsis } from 'lucide-react';
import moment from 'moment';

const data: Payment[] = [
  {
    id: 'm5gr84i9',
    amount: 316,
    status: 'success',
    email: 'ken99@yahoo.com',
    name: 'AAA Electronic Concrete Cheese',
    createdAt: '2006-10-13T14:46:05.818Z',
    fileRecognitionStatus: 2,
    resource: 'Сайт Политеха',
    createdBy: 'Zoe',
  },
  {
    id: 'm5gr84i9',
    amount: 316,
    status: 'success',
    email: 'dddken99@yahoo.com',
    name: 'BBB Refined Plastic Pizza',
    createdAt: '2013-10-07T01:44:43.285Z',
    fileRecognitionStatus: 1,
    resource: 'Сайт Политеха',
    createdBy: 'Ryley',
  },
  {
    id: 'm5gr84i9',
    amount: 316,
    status: 'success',
    email: 'aaaken99@yahoo.com',
    name: 'CCC Refined Cotton Gloves',
    createdAt: '1987-08-31T15:49:22.344Z',
    fileRecognitionStatus: 0,
    resource: 'Телеграм',
    createdBy: 'Lilian',
  },
  {
    id: 'm5gr84i9',
    amount: 316,
    status: 'success',
    email: 'aaaken99@yahoo.com',
    name: 'DDD Luxurious Steel Chair',
    createdAt: '1995-08-22T22:47:55.552Z',
    fileRecognitionStatus: 4,
    resource: 'Сайт Политеха',
    createdBy: 'Alysha',
  },
];


export type Payment = {
  id: string
  amount: number
  status: "pending" | "processing" | "success" | "failed"
  email: string
  name: string;
  createdAt: string;
  fileRecognitionStatus: number;
  resource: string;
  createdBy: string;
}





export const columns: ColumnDef<Payment>[] = [
  {
    id: "select",
    header: ({ table }) => (
      <Checkbox
        checked={
          table.getIsAllPageRowsSelected() ||
          (table.getIsSomePageRowsSelected() && "indeterminate")
        }
        onCheckedChange={(value) => table.toggleAllPageRowsSelected(!!value)}
        aria-label="Select all"
      />
    ),
    cell: ({ row }) => (
      <Checkbox
        checked={row.getIsSelected()}
        onCheckedChange={(value) => row.toggleSelected(!!value)}
        aria-label="Select row"
      />
    ),
    enableSorting: false,
    enableHiding: false,
  },
  
  {
    accessorKey: "name",
    header: ({ column }) => {
      return (
        <Button
          variant="ghost"
          onClick={() => column.toggleSorting(column.getIsSorted() === "asc")}
        >
          Название
          <ChevronsUpDown className="ml-2 h-4 w-4" />
        </Button>
      )
    },
    cell: ({ row }) =>(row.getValue("name")),
  },
  {
    accessorKey: "createdAt",
    header: "Время добавления",
    cell: ({ row }) => (
      moment(row.getValue("createdAt")).format('hh:mm - DD.MM.YYYY')

    )
  },
  {
    accessorKey: "fileRecognitionStatus",
    header: "Статус распознования",
    cell: ({ row }) => (
      row.getValue("fileRecognitionStatus")
    ),
  },
  {
    accessorKey: "resource",
    header: "Ресурс",
    cell: ({ row }) => (
      row.getValue("resource")
    ),
  },
  {
    accessorKey: "createdBy",
    header: "Пользователь",
    cell: ({ row }) => (
      row.getValue("createdBy")
    ),
  },
  {
    id: "actions",
    enableHiding: false,
    cell: ({ row }) => {
      const payment = row.original

      return (
        <DropdownMenu>
          <DropdownMenuTrigger asChild>
            <Button variant="ghost" className="h-8 w-8 p-0">
              <span className="sr-only">Open menu</span>
              <Ellipsis className="h-4 w-4" />
            </Button>
          </DropdownMenuTrigger>
          <DropdownMenuContent align="end">
            <DropdownMenuLabel>Actions</DropdownMenuLabel>
            <DropdownMenuItem
              onClick={() => navigator.clipboard.writeText(payment.id)}
            >
              Copy payment ID
            </DropdownMenuItem>
            <DropdownMenuSeparator />
            <DropdownMenuItem>View customer</DropdownMenuItem>
            <DropdownMenuItem>View payment details</DropdownMenuItem>
          </DropdownMenuContent>
        </DropdownMenu>
      )
    },
  },
]



interface IDocumentsTableProps {}
const DocumentsTable: React.FC<IDocumentsTableProps>  = () => {
  const vm = useGet<IDocumentsTableVM>(ServiceSymbols.IDocumentsTableVM);

  const documents = vm.data;

  // return (
  //   <Table>
  //     <TableRow>
  //       <TableHead>Название</TableHead>
  //       <TableHead>Время добавления</TableHead>
  //       <TableHead>Статус распознавания</TableHead>
  //       <TableHead>Ресурс</TableHead>
  //       <TableHead>Пользователь</TableHead>
  //     </TableRow>
  //     <TableBody>
  //       {documents.map((document) => (
  //         <TableRow key={document.name}>
  //           <TableCell>{document.name}</TableCell>
  //           <TableCell>{moment(document.createdAt).format('hh:mm - DD.MM.YYYY')}</TableCell>
  //           <TableCell>{document.fileRecognitionStatus}</TableCell>
  //           <TableCell>{document.resource}</TableCell>
  //           <TableCell>{document.createdBy}</TableCell>
  //         </TableRow>
  //       ))}
  //     </TableBody>
  //   </Table>
  // );

  const [sorting, setSorting] = React.useState<SortingState>([])
  const [columnFilters, setColumnFilters] = React.useState<ColumnFiltersState>(
    []
  )
  const [columnVisibility, setColumnVisibility] =
    React.useState<VisibilityState>({})
  const [rowSelection, setRowSelection] = React.useState({})

  const table = useReactTable({
    data,
    columns,
    onSortingChange: setSorting,
    onColumnFiltersChange: setColumnFilters,
    getCoreRowModel: getCoreRowModel(),
    getPaginationRowModel: getPaginationRowModel(),
    getSortedRowModel: getSortedRowModel(),
    getFilteredRowModel: getFilteredRowModel(),
    onColumnVisibilityChange: setColumnVisibility,
    onRowSelectionChange: setRowSelection,
    state: {
      sorting,
      columnFilters,
      columnVisibility,
      rowSelection,
    },
  })

  return (
    <div className="w-full">
      <div className="flex items-center py-4">
        <Input
          placeholder="Filter emails..."
          value={(table.getColumn("name")?.getFilterValue() as string) ?? ""}
          onChange={(event) =>
            table.getColumn("name")?.setFilterValue(event.target.value)
          }
          className="max-w-sm"
        />
        <DropdownMenu>
          <DropdownMenuTrigger asChild>
            <Button variant="outline" className="ml-auto">
              Вид 
            </Button>
          </DropdownMenuTrigger>
          <DropdownMenuContent align="end">
            {table
              .getAllColumns()
              .filter((column) => column.getCanHide())
              .map((column) => {
                return (
                  <DropdownMenuCheckboxItem
                    key={column.id}
                    className="capitalize"
                    checked={column.getIsVisible()}
                    onCheckedChange={(value) =>
                      column.toggleVisibility(!!value)
                    }
                  >
                    {column.id}
                  </DropdownMenuCheckboxItem>
                )
              })}
          </DropdownMenuContent>
        </DropdownMenu>
      </div>
      <div className="rounded-md border">
        <Table>
          <TableHeader>
            {table.getHeaderGroups().map((headerGroup) => (
              <TableRow key={headerGroup.id}>
                {headerGroup.headers.map((header) => {
                  return (
                    <TableHead key={header.id}>
                      {header.isPlaceholder
                        ? null
                        : flexRender(
                          header.column.columnDef.header,
                          header.getContext()
                        )}
                    </TableHead>
                  )
                })}
              </TableRow>
            ))}
          </TableHeader>
          <TableBody>
            {table.getRowModel().rows?.length ? (
              table.getRowModel().rows.map((row) => (
                <TableRow
                  key={row.id}
                  data-state={row.getIsSelected() && "selected"}
                >
                  {row.getVisibleCells().map((cell) => (
                    <TableCell key={cell.id}>
                      {flexRender(
                        cell.column.columnDef.cell,
                        cell.getContext()
                      )}
                    </TableCell>
                  ))}
                </TableRow>
              ))
            ) : (
              <TableRow>
                <TableCell
                  colSpan={columns.length}
                  className="h-24 text-center"
                >
                  No results.
                </TableCell>
              </TableRow>
            )}
          </TableBody>
        </Table>
      </div>
      <div className="flex items-center justify-end space-x-2 py-4">
        <div className="flex-1 text-sm text-muted-foreground">
          {table.getFilteredSelectedRowModel().rows.length} of{" "}
          {table.getFilteredRowModel().rows.length} row(s) selected.
        </div>
        <div className="space-x-2">
          <Button
            variant="outline"
            size="sm"
            onClick={() => table.previousPage()}
            disabled={!table.getCanPreviousPage()}
          >
            Previous
          </Button>
          <Button
            variant="outline"
            size="sm"
            onClick={() => table.nextPage()}
            disabled={!table.getCanNextPage()}
          >
            Next
          </Button>
        </div>
      </div>
    </div>
  )
}

export default observer(DocumentsTable);