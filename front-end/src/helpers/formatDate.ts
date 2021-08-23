export function formatDate(date: string) {

    const newDate = new Date(date);
    newDate.setDate(newDate.getDate() + 1);
    
    return newDate.toLocaleDateString('pt-BR');

}