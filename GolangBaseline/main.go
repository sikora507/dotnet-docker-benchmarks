package main

import (
	"bufio"
	"io"
	"log"
	"net/http"
	"os"
)

func main() {
	resp, _ := http.Get("https://www.google.com")
	body, _ := io.ReadAll(resp.Body)
	log.Print("Hello from golang baseline.")
	log.Printf("Got %d bytes.", len(body))
	input := bufio.NewScanner(os.Stdin)
	input.Scan()
}
