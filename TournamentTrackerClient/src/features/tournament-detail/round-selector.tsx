import * as React from "react";

import {
  Select,
  SelectContent,
  SelectGroup,
  SelectItem,
  SelectLabel,
  SelectTrigger,
  SelectValue,
} from "@/features/ui/select";

export function RoundSelector() {
  return (
    <Select defaultValue="apple">
      <SelectTrigger className="w-[180px]">
        <SelectValue placeholder="Select a round" />
      </SelectTrigger>
      <SelectContent>
        <SelectGroup>
          <SelectLabel>Rounds</SelectLabel>
          <SelectItem value="apple">Round 1</SelectItem>
          <SelectItem value="banana">Round 2</SelectItem>
        </SelectGroup>
      </SelectContent>
    </Select>
  );
}
