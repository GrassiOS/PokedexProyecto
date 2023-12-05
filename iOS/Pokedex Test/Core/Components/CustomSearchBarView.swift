//
//  CustomSearchBarView.swift
//  Pokedex Test
//
//  Created by Martin on 05/11/23.
//

import SwiftUI

struct CustomSearchBarView: View {
    @Binding var searchText: String
    
    var body: some View {
        RoundedRectangle(cornerRadius: 10)
            .frame(width: 220, height: 40)
            .foregroundColor(Color(red: 0.88, green: 0.88, blue: 0.88))
            .overlay {
                HStack {
                    TextField("Search", text: $searchText)
                        .autocapitalization(.none)
                        .font(.subheadline)
                        .padding(.leading, 8)
                    
                    Image(systemName: "magnifyingglass")
                        .padding(.trailing, 8)
                    
                    if !searchText.isEmpty {
                        Button(action: {
                            searchText = ""
                        }) {
                            Image(systemName: "xmark.circle.fill")
                                .foregroundColor(.gray)
                                .padding(.trailing, 8) 
                        }
                    }
                }
            }
    }
}

