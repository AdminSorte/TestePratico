interface GenerateToday {
  date: string
  hour: string
}

export function generateToday(): GenerateToday {
  const today = new Date()
  const date = __returnWithZeroIfLessThan10(today.getDate())
  const month = __returnWithZeroIfLessThan10(today.getMonth() + 1)
  const year = today.getFullYear()
  const hour = __returnWithZeroIfLessThan10(today.getHours())
  const minute = __returnWithZeroIfLessThan10(today.getMinutes())

  const dateString = `${date}/${month}/${year}`
  const hourString = `${hour}:${minute}`

  return {
    date: dateString,
    hour: hourString,
  }
}

function __returnWithZeroIfLessThan10(number: number): string {
  return number < 10 ? `0${number}` : number.toString()
}
